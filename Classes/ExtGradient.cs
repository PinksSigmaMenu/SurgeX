using System;
using UnityEngine;

namespace StupidTemplate.Classes
{
    public class ExtGradient
    {
        public GradientColorKey[] colors = new GradientColorKey[]
        {
            new GradientColorKey(Color.black, 0f),
            new GradientColorKey(Color.magenta, 0.5f),
            new GradientColorKey(Color.black, 1f)
        };

        public bool isRainbow = false;
        public bool copyRigColors = false;

        public Color StartColor
        {
            get { return colors[0].color; }
            set { colors[0].color = value; }
        }

        public Color EndColor
        {
            get { return colors[colors.Length - 1].color; }
            set { colors[colors.Length - 1].color = value; }
        }
    }
}