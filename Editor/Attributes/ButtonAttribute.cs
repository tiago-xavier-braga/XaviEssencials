using System;
using UnityEngine;

namespace XaviEssencials
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
    }
}
