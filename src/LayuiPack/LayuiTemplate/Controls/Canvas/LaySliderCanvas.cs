﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LayuiTemplate.Controls
{
    /// <summary>
    /// 滑块专用画布
    /// </summary>
    public class LaySliderCanvas : Canvas
    {
        [Bindable(true)]
        public Orientation Orientation
        {
            get => (Orientation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }
        public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(
            "Orientation", typeof(Orientation), typeof(LaySliderCanvas), new PropertyMetadata(default(Orientation)));

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            foreach (UIElement internalChild in InternalChildren)
            {
                if (internalChild == null) continue;

                var x = 0.0;
                var y = 0.0;

                if (Orientation == Orientation.Horizontal)
                {
                    x = (arrangeSize.Width - internalChild.DesiredSize.Width) / 2;

                    var top = GetTop(internalChild);
                    if (!double.IsNaN(top))
                    {
                        y = top;
                    }
                    else
                    {
                        var bottom = GetBottom(internalChild);
                        if (!double.IsNaN(bottom))
                            y = arrangeSize.Height - internalChild.DesiredSize.Height - bottom;
                    }
                }
                else
                {
                    y = (arrangeSize.Height - internalChild.DesiredSize.Height) / 2;

                    var left = GetLeft(internalChild);
                    if (!double.IsNaN(left))
                    {
                        x = left;
                    }
                    else
                    {
                        var right = GetRight(internalChild);
                        if (!double.IsNaN(right))
                            x = arrangeSize.Width - internalChild.DesiredSize.Width - right;
                    }
                }

                internalChild.Arrange(new Rect(new Point(x, y), internalChild.DesiredSize));
            }
            return arrangeSize;
        }
    }
}
