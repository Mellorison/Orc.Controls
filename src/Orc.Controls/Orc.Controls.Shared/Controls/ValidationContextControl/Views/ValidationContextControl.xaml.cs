﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationContextControl.xaml.cs" company="WildGums">
//   Copyright (c) 2008 - 2016 WildGums. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Orc.Controls
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media;
    using Catel.Data;
    using Catel.MVVM.Views;

    public sealed partial class ValidationContextControl
    {
        static ValidationContextControl()
        {
            typeof (ValidationContextControl).AutoDetectViewPropertiesToSubscribe();
        }

        public ValidationContextControl()
        {
            this.InitializeComponent();
        }

        #region Dependency properties
        [ViewToViewModel(MappingType = ViewToViewModelMappingType.ViewToViewModel)]
        public IValidationContext ValidationContext
        {
            get { return (IValidationContext) GetValue(ValidationContextProperty); }
            set { SetValue(ValidationContextProperty, value); }
        }

        public static readonly DependencyProperty ValidationContextProperty = DependencyProperty.Register(
            "ValidationContext", typeof(IValidationContext), typeof(ValidationContextControl), new PropertyMetadata(null));        

        [ViewToViewModel(MappingType = ViewToViewModelMappingType.ViewToViewModel)]
        public bool ShowErrors
        {
            get { return (bool) GetValue(ShowErrorsProperty); }
            set { SetValue(ShowErrorsProperty, value); }
        }

        public static readonly DependencyProperty ShowErrorsProperty = DependencyProperty.Register(
            "ShowErrors", typeof(bool), typeof(ValidationContextControl), new PropertyMetadata(true));

        [ViewToViewModel(MappingType = ViewToViewModelMappingType.ViewToViewModel)]
        public bool ShowWarnings
        {
            get { return (bool) GetValue(ShowWarningsProperty); }
            set { SetValue(ShowWarningsProperty, value); }
        }

        public static readonly DependencyProperty ShowWarningsProperty = DependencyProperty.Register(
            "ShowWarnings", typeof(bool), typeof(ValidationContextControl), new PropertyMetadata(true));        

        public Brush AccentColorBrush
        {
            get { return (Brush) GetValue(AccentColorBrushProperty); }
            set { SetValue(AccentColorBrushProperty, value); }
        }

        public static readonly DependencyProperty AccentColorBrushProperty = DependencyProperty.Register(
            "AccentColorBrush", typeof(Brush), typeof(ValidationContextControl), new PropertyMetadata(Brushes.LightGray,
                (sender, e) => ((ValidationContextControl)sender).OnAccentColorBrushChanged()));

        [ViewToViewModel(MappingType = ViewToViewModelMappingType.ViewToViewModel)]
        public string Filter
        {
            get { return (string) GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register(
            "Filter", typeof (string), typeof (ValidationContextControl), new PropertyMetadata(default(string)));

        [ViewToViewModel(MappingType = ViewToViewModelMappingType.ViewModelToView)]
        public IEnumerable<IValidationContextTreeNode> Nodes
        {
            get { return (IEnumerable<IValidationContextTreeNode>) GetValue(NodesProperty); }
            set { SetValue(NodesProperty, value); }
        }

        public static readonly DependencyProperty NodesProperty = DependencyProperty.Register(
            "Nodes", typeof (IEnumerable<IValidationContextTreeNode>), typeof (ValidationContextControl), new PropertyMetadata(default(IEnumerable<IValidationContextTreeNode>)));
        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            AccentColorBrush = TryFindResource("AccentColorBrush") as SolidColorBrush;
        }

        private void OnAccentColorBrushChanged()
        {
            var solidColorBrush = AccentColorBrush as SolidColorBrush;
            if (solidColorBrush != null)
            {
                var accentColor = ((SolidColorBrush)AccentColorBrush).Color;
                accentColor.CreateAccentColorResourceDictionary("ValidationContextControl");
            }
        }
    }
}