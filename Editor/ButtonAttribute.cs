using System;
using UnityEngine;

namespace XaviEssencials.Editor
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ButtonAttribute : PropertyAttribute
    {
        public string ButtonName { get; }
        public bool ShowInPlayModeOnly { get; }

        public ButtonAttribute(string buttonName = "", bool showInPlayModeOnly = false)
        {
            ButtonName = buttonName;
            ShowInPlayModeOnly = showInPlayModeOnly;
        }

        public ButtonAttribute(bool showInPlayModeOnly = false)
        {
            ButtonName = string.Empty;
            ShowInPlayModeOnly = showInPlayModeOnly;
        }
    }
}
