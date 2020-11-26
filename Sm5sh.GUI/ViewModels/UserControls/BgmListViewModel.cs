﻿using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Threading;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace Sm5sh.GUI.ViewModels
{
    public class BgmListViewModel : ViewModelBase, IDisposable
    {
        private readonly ReadOnlyObservableCollection<BgmEntryViewModel> _items;
        private readonly Subject<BgmEntryViewModel> _whenNewRequestToEditBgmEntry;
        private readonly Subject<BgmEntryViewModel> _whenNewRequestToDeleteBgmEntry;
        private readonly Subject<Unit> _whenNewRequestToReorderBgmEntries;
        private const string DATAOBJECT_FORMAT = "BGM";
        private Action _postReorderSelection;

        public IObservable<BgmEntryViewModel> WhenNewRequestToEditBgmEntry { get { return _whenNewRequestToEditBgmEntry; } }
        public IObservable<BgmEntryViewModel> WhenNewRequestToDeleteBgmEntry { get { return _whenNewRequestToDeleteBgmEntry; } }
        public IObservable<Unit> WhenNewRequestToReorderBgmEntries { get { return _whenNewRequestToReorderBgmEntries; } }

        public ReadOnlyObservableCollection<BgmEntryViewModel> Items { get { return _items; } }

        [Reactive]
        public BgmEntryViewModel SelectedBgmEntry { get; private set; }

        public ReactiveCommand<DataGridCellPointerPressedEventArgs, Unit> ActionReorderBgm { get; }
        public ReactiveCommand<UserControl, Unit> ActionInitializeDragAndDrop { get; }
        public ReactiveCommand<BgmEntryViewModel, Unit> ActionEditBgm { get; }
        public ReactiveCommand<BgmEntryViewModel, Unit> ActionDeleteBgm { get; }


        public BgmListViewModel(IObservable<IChangeSet<BgmEntryViewModel, string>> observableBgmEntries)
        {
            _whenNewRequestToEditBgmEntry = new Subject<BgmEntryViewModel>();
            _whenNewRequestToDeleteBgmEntry = new Subject<BgmEntryViewModel>();
            _whenNewRequestToReorderBgmEntries = new Subject<Unit>();

            observableBgmEntries
                .AutoRefresh(p => p.SoundTestIndex, TimeSpan.FromMilliseconds(1))
                .Sort(SortExpressionComparer<BgmEntryViewModel>.Ascending(p => p.HiddenInSoundTest).ThenByAscending(p => p.SoundTestIndex), SortOptimisations.ComparesImmutableValuesOnly, 8000)
                .TreatMovesAsRemoveAdd()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _items)
                .DisposeMany()
                .Subscribe((o) => FocusAfterMove());

            ActionReorderBgm = ReactiveCommand.CreateFromTask<DataGridCellPointerPressedEventArgs>(ReorderBgm);
            ActionInitializeDragAndDrop = ReactiveCommand.Create<UserControl>(InitializeDragAndDropHandlers);
            ActionEditBgm = ReactiveCommand.Create<BgmEntryViewModel>(EditBgmEntry);
            ActionDeleteBgm = ReactiveCommand.Create<BgmEntryViewModel>(DeleteBgmEntry);
        }

        #region DELETE/EDIT BGM PROPERTIES
        public void EditBgmEntry(BgmEntryViewModel bgmEntry)
        {
            _whenNewRequestToEditBgmEntry.OnNext(bgmEntry);
        }
        public void DeleteBgmEntry(BgmEntryViewModel bgmEntry)
        {
            _whenNewRequestToDeleteBgmEntry.OnNext(bgmEntry);
        }
        #endregion

        #region REORDER
        public void InitializeDragAndDropHandlers(UserControl userControl)
        {
            userControl.AddHandler(DragDrop.DropEvent, Drop);
            userControl.AddHandler(DragDrop.DragOverEvent, DragOver);
        }

        public async Task ReorderBgm(DataGridCellPointerPressedEventArgs e)
        {
            var dragData = new DataObject();

            if (e.Cell.DataContext is BgmEntryViewModel vmBgmEntry)
            {
                dragData.Set(DATAOBJECT_FORMAT, vmBgmEntry);

                if (!vmBgmEntry.HiddenInSoundTest)
                    await DragDrop.DoDragDrop(e.PointerPressedEventArgs, dragData, DragDropEffects.Move);
            }
        }

        public void DragOver(object sender, DragEventArgs e)
        {
            e.DragEffects &= DragDropEffects.Move;
            if (!e.Data.Contains(DATAOBJECT_FORMAT))
                e.DragEffects = DragDropEffects.None;

            var destinationObj = ((Control)e.Source).DataContext as BgmEntryViewModel;
            if(destinationObj.HiddenInSoundTest)
                e.DragEffects = DragDropEffects.None;
        }

        public void Drop(object sender, DragEventArgs e)
        {
            var source = e.Source;
            while (!(source is DataGrid))
            {
                source = source.InteractiveParent;
            }
            var dataGrid = (DataGrid)source;

            if (((Control)e.Source).DataContext is BgmEntryViewModel destinationObj 
                && e.Data.Get(DATAOBJECT_FORMAT) is BgmEntryViewModel sourceObj 
                && !destinationObj.HiddenInSoundTest 
                && sourceObj != destinationObj)
            {
                var isHigherThanDest = sourceObj.SoundTestIndex > destinationObj.SoundTestIndex;
                sourceObj.SoundTestIndex = destinationObj.SoundTestIndex;
                if (isHigherThanDest)
                    destinationObj.SoundTestIndex += 1;
                else
                    destinationObj.SoundTestIndex -= 1;
                _postReorderSelection = () => dataGrid.SelectedItem = sourceObj;

                _whenNewRequestToReorderBgmEntries.OnNext(Unit.Default);
            }
        }

        public void FocusAfterMove()
        {
            if (_postReorderSelection != null)
            {
                _postReorderSelection();
                _postReorderSelection = null;
            }
        }
        #endregion

        public void Dispose()
        {
            if (_whenNewRequestToEditBgmEntry != null)
            {
                _whenNewRequestToEditBgmEntry?.OnCompleted();
                _whenNewRequestToEditBgmEntry?.Dispose();
            }
            if (_whenNewRequestToReorderBgmEntries != null)
            {
                _whenNewRequestToReorderBgmEntries?.OnCompleted();
                _whenNewRequestToReorderBgmEntries?.Dispose();
            }
            if (_whenNewRequestToDeleteBgmEntry != null)
            {
                _whenNewRequestToDeleteBgmEntry?.OnCompleted();
                _whenNewRequestToDeleteBgmEntry?.Dispose();
            }
        }
    }
}
