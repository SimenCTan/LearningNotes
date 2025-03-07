﻿using CommunityToolkit.Maui.Views;
using MauiNewFeature.ViewModels;
using MauiNewFeature.Views;
using System.IO;

namespace MauiNewFeature;

public partial class MainPage : ContentPage
{
    private readonly MainViewModel _viewModel;

    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        //Android.Manifest.Permission.ReadExternalStorage
        //var result = await FilePicker.Default.PickAsync(new PickOptions
        //{
        //    FileTypes = FilePickerFileType.Images,
        //    PickerTitle = "Pick image please!"
        //});
        //if (result == null) return;
        //var stream=await result.OpenReadAsync();
        //myImage.Source = ImageSource.FromStream(() => stream);

        // popup
        //var popup = new PopupSimple();
        //popup.Anchor = CounterBtn;
        //this.ShowPopup(popup);

        // capture image
        var result = await screenCapture.CaptureAsync();
        using MemoryStream stream = new();
        await result.CopyToAsync(stream, ScreenshotFormat.Png);
        await File.WriteAllBytesAsync("D:\\github\\LearningNotes\\src\\dotNet\\MauiSamples\\MauiNewFeature\\images\\mauiscreen.png",stream.ToArray());
    }
}

