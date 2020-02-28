// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

#if UNITY_EDITOR
    using UnityEditor;
#endif


namespace HutongGames.PlayMaker.PostProcessing.Actions
{
    // Base class for Post Processing actions.
    public abstract class PpsActionBase : FsmStateAction
    {

#if UNITY_EDITOR && PLAYMAKER_1_9_OR_NEWER

        [DisplayOrder(0)]
        [HideIf("HideActionHeader")]
        public PpsActionHeader header;

        const string HideActionHeaderPrefsKey = "PlayMaker.Ecosystem.PostProcessing.HideActionHeader";

		public override void InitEditor (Fsm fsmOwner)
		{
		    PpsActionHeader.HideActionHeader = EditorPrefs.GetBool(HideActionHeaderPrefsKey, false);

        }

        public bool HideActionHeader()
        {
            return PpsActionHeader.HideActionHeader;
        }

        [SettingsMenuItem("Hide Action Header")]
        public static void ToggleActionHeader()
        {
            PpsActionHeader.HideActionHeader = !PpsActionHeader.HideActionHeader;
            EditorPrefs.SetBool(HideActionHeaderPrefsKey, PpsActionHeader.HideActionHeader);
        }

        [SettingsMenuItemState("Hide Action Header")]
        public static bool ToggleActionHeaderState()
        {
            return PpsActionHeader.HideActionHeader;
        }
        
#endif
        
    }
}