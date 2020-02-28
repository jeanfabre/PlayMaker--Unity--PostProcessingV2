// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License
// Original Action made by Waveform

using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace HutongGames.PlayMaker.PostProcessing.Actions
{

	[ActionCategory("Post Processing")]
	public class SetVignette : PpsActionBase
	{

	    public PpsProfileReferenceProperty profile;

        [ActionSection("Enable")]
        public FsmBool SetEnable;
        public FsmBool EnableValue;

        [ActionSection("Mode")]
        public FsmBool SetMode;
        [ObjectType(typeof(VignetteMode))]
        public FsmEnum ModeValue;

        [ActionSection("Color")]
        public FsmBool SetColor;
        public FsmColor ColorValue;

        [ActionSection("Center")]
        public FsmBool SetCenter;
        public FsmVector2 CenterValue;

        [ActionSection("Intensity")]
        public FsmBool SetIntensity;
        [HasFloatSlider(0,1)]
        public FsmFloat IntensityValue;

        [ActionSection("Smoothness")]
        public FsmBool SetSmoothness;
        [HasFloatSlider(0.01f,1)]
        public FsmFloat SmoothnessValue;

        [ActionSection("Roundness")]
        public FsmBool SetRoundness;
        [HasFloatSlider(0,1)]
        public FsmFloat RoundnessValue;

        [ActionSection("Rounded")]
        public FsmBool SetRounded;
        public FsmBool RoundedValue;

        [ActionSection(" ")]
        public bool everyFrame;


        private PostProcessProfile convert;

        public override void Reset()
        {
            profile = new PpsProfileReferenceProperty();

            SetEnable = false;
            EnableValue = false;

            SetMode = false;
            ModeValue = VignetteMode.Classic;

            SetColor = false;
            ColorValue = null;

            SetCenter = false;
            CenterValue = new Vector2 (0.5f,0.5f);

            SetIntensity = false;
            IntensityValue = 0;

            SetSmoothness = false;
            SmoothnessValue = 0.2f;

            SetRoundness = false;
            RoundnessValue = 1;

            SetRounded = false;
            RoundedValue = false;

            everyFrame = false;

        }
        public override void OnEnter()
		{
            executeAction();

            if(!everyFrame)
            {
                Finish();
            }

        }

        public override void OnUpdate()
        {
            executeAction();
        }
	    
	    
        private void executeAction()
        {

            Vignette vignette;
           
            convert.TryGetSettings(out vignette);

            if (SetEnable.Value)
                vignette.enabled.value = EnableValue.Value;
            if (SetMode.Value)
                vignette.mode.value = (VignetteMode)ModeValue.Value;

            if (!SetColor.IsNone)
            {
                vignette.color.overrideState = SetColor.Value;
            }

                if (!ColorValue.IsNone)
                {
                    vignette.color.value = ColorValue.Value;
                }

            if (SetCenter.Value)
                vignette.center.value = CenterValue.Value;
            if (SetIntensity.Value)
                vignette.intensity.value = IntensityValue.Value;
            if (SetSmoothness.Value)
                vignette.smoothness.value = SmoothnessValue.Value;
            if (SetRoundness.Value)
                vignette.roundness.value = RoundnessValue.Value;
            if (SetRounded.Value)
                vignette.rounded.value = RoundedValue.Value;

        }
	}

}
