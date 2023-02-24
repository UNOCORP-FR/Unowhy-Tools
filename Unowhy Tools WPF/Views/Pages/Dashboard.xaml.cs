﻿using Wpf.Ui.Common.Interfaces;
using Unowhy_Tools_WPF.ViewModels;
using System.Windows;

using Unowhy_Tools;
using System.Diagnostics;

namespace Unowhy_Tools_WPF.Views.Pages;

/// <summary>
/// Interaction logic for Dashboard.xaml
/// </summary>
public partial class Dashboard : INavigableView<DashboardViewModel>
{
    UT.Data UTdata = new UT.Data();

    public DashboardViewModel ViewModel
    {
        get;
    }

    public Dashboard(DashboardViewModel viewModel)
    {
        ViewModel = viewModel;

        InitializeComponent();

        string ver = "Version " + UT.version.getver() + " (Build " + UT.version.getverbuild().ToString() + ") ";

        if (UT.version.isdeb()) ver = ver + "(Debug/Beta)";
        else ver = ver + "(Release)";

        verlab.Text = ver;

        applylang();
        pcname.Text = UT.GetLine(UTdata.HostName, 1);
    }

    public void applylang()
    {
        lababout.Text = UT.GetLang("about");
        labinfo.Text = UT.GetLang("pcinfo");
        labset.Text = UT.GetLang("settings");
    }

    public void Taskmgr(object sender, RoutedEventArgs e)
    {
        System.Diagnostics.Process.Start("taskmgr.exe");
    }
    
    public void CMD(object sender, RoutedEventArgs e)
    {
        //System.Diagnostics.Process.Start("cmd.exe");
        Process p = new Process();
        p.StartInfo.FileName = "cmd.exe";
        p.StartInfo.WorkingDirectory = "C:\\Windows\\System32\\";
        p.Start();
    }
    
    public void Regedit(object sender, RoutedEventArgs e)
    {
        System.Diagnostics.Process.Start("regedit.exe");
    }

    public void Gpedit(object sender, RoutedEventArgs e)
    {
        System.Diagnostics.Process.Start("mmc.exe", "gpedit.msc");
    }

    public void Guide(object sender, RoutedEventArgs e)
    {
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = "https://github.com/STY1001/Unowhy-Tools/blob/master/GUIDE.md", UseShellExecute = true });
    }
}
