// (c) Copyright HutongGames, LLC 2010-2019. All rights reserved.
// Author jean@hutonggames.com
// This code is licensed under the MIT Open source License

using HutongGames.PlayMakerEditor;
using UnityEngine;

using UnityEditor;

[InitializeOnLoad]
public class PostProcessingEditorUtils
{

    static PostProcessingEditorUtils()
    {
        Actions.AddCategoryIcon("Post Processing",CategoryIcon);
    }

    private static Texture sCategoryIcon = null;
    internal static Texture CategoryIcon
    {
        get
        {
            if (sCategoryIcon == null)
                sCategoryIcon = Resources.Load<Texture>("PostProcessing_playmaker_category_icon");
            ;
            if (sCategoryIcon != null)
                sCategoryIcon.hideFlags = HideFlags.DontSaveInEditor;
            return sCategoryIcon;
        }
    }


}
