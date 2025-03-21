﻿using CommunityToolkit.Maui.Markup;
using MauiNewFeature.Models;
using MauiNewFeature.ViewModels.Base;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace MauiNewFeature.Pages.Base;

public abstract class BaseGalleryPage<TViewModel>:BasePage<TViewModel> where TViewModel:BaseGalleryViewModel
{
    protected BaseGalleryPage(string title, IDeviceInfo deviceInfo, TViewModel viewModel) : base(viewModel)
    {
        Title = title;

        Padding = 0;

        Content = new CollectionView
        {
            SelectionMode = SelectionMode.Single,
        }.ItemTemplate(new GalleryDataTemplate())
         .Bind(ItemsView.ItemsSourceProperty, nameof(BaseGalleryViewModel.Items))
         .Invoke(collectionView => collectionView.SelectionChanged += HandleSelectionChanged);
    }



    async void HandleSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var collectionView = (CollectionView)sender;
        if (collectionView.SelectedItem is null ||collectionView.SelectedItems is null)
        {
            return;
        }
        ArgumentNullException.ThrowIfNull(sender);
        if (e.CurrentSelection.FirstOrDefault() is SectionModel sectionModel)
        {
            await Shell.Current.GoToAsync(AppShell.GetPageRoute(sectionModel.ViewModelType));
        }
        collectionView.SelectedItem = null;
        collectionView.SelectedItems = null;
    }

    class GalleryDataTemplate : DataTemplate
    {
        public GalleryDataTemplate() : base(CreateDataTemplate)
        {
        }
        enum Row { TopPadding, Content, BottomPadding }
        enum Column { LeftPadding, Content, RightPadding }
        enum CardRow { Title, Description }
        static Grid CreateDataTemplate() => new()
        {
            RowDefinitions = Rows.Define(
                (Row.TopPadding, 12),
                (Row.Content, Star),
                (Row.BottomPadding, 12)),
            ColumnDefinitions = Columns.Define(
                (Column.LeftPadding, 24),
                (Column.Content, Star),
                (Column.RightPadding, 24)),
            Children =
            {
                new Card().Row(Row.Content).Column(Column.Content).DynamicResource(Border.StyleProperty, "border_gallery_card")
            }
        };

        class Card : Border
        {
            public Card()
            {
                Content = new Grid
                {
                    BackgroundColor = Colors.Transparent,
                    RowSpacing = 4,
                    RowDefinitions = Rows.Define(
                        (CardRow.Title, 24),
                        (CardRow.Description, Auto)),
                    ColumnDefinitions = Columns.Define(Star),
                    Children =
                    {
                        new Label()
                            .Row(CardRow.Title)
                            .Bind(Label.TextProperty, nameof(SectionModel.Title))
                            .DynamicResource(Label.StyleProperty, "label_section_title"),

                        new Label { MaxLines = 4, LineBreakMode = LineBreakMode.WordWrap }
                            .Row(CardRow.Description).TextStart().TextTop()
                            .Bind(Label.TextProperty, nameof(SectionModel.Description))
                            .DynamicResource(Label.StyleProperty, "label_section_text")
                    }
                };
            }
        }
    }
}
