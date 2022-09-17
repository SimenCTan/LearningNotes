﻿using MauiNewFeature.ViewModels.Base;
namespace MauiNewFeature.Models;

public sealed class SectionModel
{ 
    public Type ViewModelType { get; }

    public string Title { get; }

    public string Description { get; }

    public Color Color { get; }

    // Use a private constructor to enforce the Factory Pattern
    // This requires us to use the `Create` methods to instantiate SectionModel
    // The Create methods allow us to use a constrained generic to ensure TViewModel inherits from BaseViewModel
    SectionModel(in Type viewModelType, in string title, in string description, in Color color)
    {
        ViewModelType= viewModelType;
        Title = title;
        Description = description;
        Color = color;
    }

    // Factory pattern using constrained generic to ensure TViewModel inherits from BaseViewModel
    public static SectionModel Create<TViewModel>(in string title, in Color color, in string description) where TViewModel : BaseViewModel
    {
        return new SectionModel(typeof(TViewModel), title, description, color);
    }

    // Factory pattern using constrained generic to ensure TViewModel inherits from BaseViewModel
    public static SectionModel Create<TViewModel>(in string title, in string description) where TViewModel : BaseViewModel
        => Create<TViewModel>(title, new Color(), description);
}
