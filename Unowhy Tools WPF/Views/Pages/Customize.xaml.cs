﻿using Wpf.Ui.Common.Interfaces;
using Unowhy_Tools_WPF.ViewModels;

using Unowhy_Tools;
using System.Threading.Tasks;
using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace Unowhy_Tools_WPF.Views.Pages;

/// <summary>
/// Interaction logic for Dashboard.xaml
/// </summary>
public partial class Customize : INavigableView<DashboardViewModel>
{
    UT.Data UTdata = new UT.Data();

    public DashboardViewModel ViewModel
    {
        get;
    }

    public void GoForw(object sender, RoutedEventArgs e)
    {
        UT.anim.TransitionForw(RootGrid);
    }
    
    public async void AdminSet_Click(object sender, RoutedEventArgs e)
    {
        DoubleAnimation anim = new DoubleAnimation();
        anim.From = 0;
        anim.To = 300;
        anim.Duration = TimeSpan.FromMilliseconds(500);
        anim.EasingFunction = new PowerEase() { EasingMode = EasingMode.EaseInOut, Power = 5 };
        TranslateTransform trans = new TranslateTransform();
        auset_btn.RenderTransform = trans;
        trans.BeginAnimation(TranslateTransform.XProperty, anim);

        await Task.Delay(200);
        UT.anim.TransitionForw(RootGrid);
        await Task.Delay(200);
        UT.NavigateTo(typeof(AdminUser));

        anim.From = 0;
        anim.To = 0;
        anim.Duration = TimeSpan.FromMilliseconds(500);
        anim.EasingFunction = new PowerEase() { EasingMode = EasingMode.EaseInOut, Power = 5 };
        auset_btn.RenderTransform = trans;
        trans.BeginAnimation(TranslateTransform.XProperty, anim);
    }
    
    public async void AddUser_Click(object sender, RoutedEventArgs e)
    {
        DoubleAnimation anim = new DoubleAnimation();
        anim.From = 0;
        anim.To = 300;
        anim.Duration = TimeSpan.FromMilliseconds(500);
        anim.EasingFunction = new PowerEase() { EasingMode = EasingMode.EaseInOut, Power = 5 };
        TranslateTransform trans = new TranslateTransform();
        adduser_btn.RenderTransform = trans;
        trans.BeginAnimation(TranslateTransform.XProperty, anim);

        await Task.Delay(200);
        UT.anim.TransitionForw(RootGrid);
        await Task.Delay(200);
        UT.NavigateTo(typeof(AdminUser));

        anim.From = 0;
        anim.To = 0;
        anim.Duration = TimeSpan.FromMilliseconds(500);
        anim.EasingFunction = new PowerEase() { EasingMode = EasingMode.EaseInOut, Power = 5 };
        adduser_btn.RenderTransform = trans;
        trans.BeginAnimation(TranslateTransform.XProperty, anim);
    }
    
    public async void PCname_Click(object sender, RoutedEventArgs e)
    {
        DoubleAnimation anim = new DoubleAnimation();
        anim.From = 0;
        anim.To = 300;
        anim.Duration = TimeSpan.FromMilliseconds(500);
        anim.EasingFunction = new PowerEase() { EasingMode = EasingMode.EaseInOut, Power = 5 };
        TranslateTransform trans = new TranslateTransform();
        pcname_btn.RenderTransform = trans;
        trans.BeginAnimation(TranslateTransform.XProperty, anim);

        await Task.Delay(200);
        UT.anim.TransitionForw(RootGrid);
        await Task.Delay(200);
        UT.NavigateTo(typeof(AdminUser));

        anim.From = 0;
        anim.To = 0;
        anim.Duration = TimeSpan.FromMilliseconds(500);
        anim.EasingFunction = new PowerEase() { EasingMode = EasingMode.EaseInOut, Power = 5 };
        pcname_btn.RenderTransform = trans;
        trans.BeginAnimation(TranslateTransform.XProperty, anim);
    }

    public void applylang()
    {
        pcname_txt.Text = UT.GetLang("pcname");
        pcname_desc.Text = UT.GetLang("descpcname");
        pcname_btn.Content = UT.GetLang("change");
        adminset_txt.Text = UT.GetLang("admin");
        adminset_desc.Text = UT.GetLang("descadmin");
        adminset_btn.Content = UT.GetLang("set");
        adduser_txt.Text = UT.GetLang("adduser");
        adduser_desc.Text = UT.GetLang("descadduser");
        adduser_btn.Content = UT.GetLang("create");
        auset_txt.Text = UT.GetLang("adminset");
        auset_desc.Text = UT.GetLang("descadminset");
        auset_btn.Content = UT.GetLang("open");
    }

    public async Task CheckBTN()
    {
        await UT.Check();
        if (UTdata.Admin == true) adminset.IsEnabled = false;
        else adminset.IsEnabled = true;
    }

    public async void Init(object sender, EventArgs e)
    {
        RootStack.Visibility = Visibility.Hidden;

        await UT.waitstatus.open();
        applylang();
        await CheckBTN();
        await UT.waitstatus.close();

        RootStack.Visibility = Visibility.Visible;

        foreach (UIElement element in RootStack.Children)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            DoubleAnimation translateAnimation = new DoubleAnimation
            {
                From = 50,
                To = 0,
                Duration = TimeSpan.FromSeconds(0.5),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            TranslateTransform transform = new TranslateTransform();
            element.RenderTransform = transform;

            element.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
            transform.BeginAnimation(TranslateTransform.XProperty, translateAnimation);

            await Task.Delay(50);
        }
    }

    public Customize(DashboardViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();
    }

    public async void adminset_Click(object sender, RoutedEventArgs e)
    {
        if (UT.DialogQShow(UT.GetLang("admin"), "admin.png"))
        {
            await UT.waitstatus.open();
            await UT.RunMin("net", $"localgroup {UTdata.AdminsName} /add \"{UTdata.User}\"");
            await CheckBTN();
            await UT.waitstatus.close();
            if (!adminset.IsEnabled)
            {
                UT.DialogIShow(UT.GetLang("done"), "yes.png");
            }
            else
            {
                UT.DialogIShow(UT.GetLang("failed"), "no.png");
            }
        }
    }
}
