using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace WinUI3_Csharp_RuntimeComponent_Sample
{
    public sealed partial class CommunityUserControl : UserControl
    {
        // Properties used by x:Bind in XAML
        public bool IsCardExpanded { get; set; } = false;
        public bool IsCardEnabled { get; set; } = true;

        // properties that can be set externally (including C++/WinRT)
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(
                nameof(ItemsSource),
                typeof(IEnumerable),
                typeof(CommunityUserControl),
                new PropertyMetadata(null, OnItemsSourceChanged));
                //new PropertyMetadata(null));

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (CommunityUserControl)d;
            if (control.Grid is not null)
            {
                control.Grid.ItemsSource = (System.Collections.IEnumerable)e.NewValue;
            }
        }

        public object ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public CommunityUserControl()
        {
            InitializeComponent();
            // Ensure synchronization between the internal grid and dependent properties after construction if we don't use x:Bind
            Grid.ItemsSource = (System.Collections.IEnumerable)ItemsSource;
        }
    }
}
namespace WinUI3_Csharp_RuntimeComponent_Sample.Models
{
    // 注意：公开的 sealed 类 + WinRT 基本类型属性，才能正常投影给 C++/WinRT 使用
    // Note: Only the publicly available sealed class + WinRT basic type properties can be properly projected to C++/WinRT for use
    public sealed class Person
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Email { get; set; } = "";
    }
}