// Made by lovely Waveform
using UnityEngine.Rendering.PostProcessing;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("Post Processing V2")]
	public class GetActiveGrain : FsmStateAction
	{
        [ActionSection("Profile")]
        [ObjectType(typeof(PostProcessProfile))]
        public FsmObject Profile;
        [ObjectType(typeof(PostProcessVolume))]
        public FsmObject Volume;
        [UIHint(UIHint.Variable)]
        [ObjectType(typeof(PostProcessVolume))]
        public FsmObject VolumeProfile;

        //[ActionSection("Enable")]
        //public FsmBool GetEnable;
        [UIHint(UIHint.Variable)]
        public FsmBool EnableValue;

        //[ActionSection("Colored")]
        //public FsmBool GetColored;
        [UIHint(UIHint.Variable)]
        public FsmBool ColoredValue;

        //[ActionSection("Intensity")]
        //public FsmBool GetIntensity;
        [UIHint(UIHint.Variable)]
        public FsmBool IntensityValue;

        //[ActionSection("Size")]
        //public FsmBool GetSize;
        [UIHint(UIHint.Variable)]
        public FsmBool SizeValue;

        //[ActionSection("Luminance Contribution")]
        //public FsmBool GetLuminanceContribution;
        [UIHint(UIHint.Variable)]
        public FsmBool LuminanceContributionValue;

        [ActionSection(" ")]
        public bool everyFrame;


        private PostProcessProfile convert;
        private PostProcessVolume convert2;

        public override void Reset()
        {
            Profile = null;
            convert = null;
            convert2 = null;
            /*
            GetEnable = false;
            GetColored = false;
            GetIntensity = false;
            GetSize = false;
            GetLuminanceContribution = false;
            */
            everyFrame = false;

        }
        public override void OnEnter()
		{
            ggop();

            if(!everyFrame)
            {
                Finish();
            }

        }

        public override void OnUpdate()
        {
            ggop();
        }
        private void ggop()
        {
            if (Profile.Value != null)
            {
                convert = (PostProcessProfile)Profile.Value;
            }
            else if (Volume.Value != null)
            {
                convert2 = (PostProcessVolume)Volume.Value;
                convert = convert2.profile;
                VolumeProfile.Value = convert;
            }
            if (convert == null)
            {
                return;
            }
            else
            {
                convert.TryGetSettings(out Grain grain);

                if (!EnableValue.IsNone)
                    EnableValue.Value=grain.active;
                if (!ColoredValue.IsNone)
                    ColoredValue.Value=grain.colored.overrideState;
                if (!IntensityValue.IsNone)
                    IntensityValue.Value=grain.intensity.overrideState;
                if (!SizeValue.IsNone)
                    SizeValue.Value=grain.size.overrideState;
                if (!LuminanceContributionValue.IsNone)
                    LuminanceContributionValue.Value=grain.lumContrib.overrideState;



            }



        }
	}

}
