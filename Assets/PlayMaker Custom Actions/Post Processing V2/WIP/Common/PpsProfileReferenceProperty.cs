// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace HutongGames.PlayMaker.PostProcessing.Actions
{
    [Serializable]
    public class PpsProfileReferenceProperty
    {

        public enum PpsReferences {FromVolume,FromAsset};

        public PpsReferences reference;

        [ObjectType(typeof(PostProcessProfile))]
        public FsmObject profile;
        
        [CheckForComponent(typeof(PostProcessVolume))]
        public FsmOwnerDefault gameObject;

        public FsmEvent profileNotFound;

        private PostProcessProfile _pps;
        private PostProcessVolume _volume;
        private GameObject _go;
        
        public PpsProfileReferenceProperty()
        {
            reference = PpsReferences.FromAsset;
            
            profile = new FsmObject(){UseVariable = true};
            
            gameObject = new FsmOwnerDefault();

        }

        public PostProcessProfile GetProfile(FsmStateAction action)
        {
            
            switch(reference)
            {
                case PpsReferences.FromAsset:
                    _pps = (PostProcessProfile)profile.Value;
                    break;
                case PpsReferences.FromVolume:

                    _go = action.Fsm.GetOwnerDefaultTarget(gameObject);
                    if (_go != null)
                    {
                        _volume = _go.GetComponent<PostProcessVolume>();

                        if (_volume != null)
                        {
                            _pps = _volume.profile;
                        }
                    }
                    break;
            }

            if (_pps == null)
            {
                action.Fsm.Event(profileNotFound);
            }

            return _pps;
        }
    }
}
