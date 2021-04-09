﻿using ReactiveUI;
using StatefulModel.EventListeners;
using System.Application.UI.Resx;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Application.UI.ViewModels
{
    public abstract class TabItemViewModel : ItemViewModel
    {
        #region Name 変更通知

        public abstract string Name { get; protected set; }

        #endregion

        #region Badge 変更通知

        private int? _Badge;

        public virtual int? Badge
        {
            get => _Badge;
            protected set => this.RaiseAndSetIfChanged(ref _Badge, value);
        }

        #endregion

        #region Status 変更通知

        private ViewModelBase? _Status;

        /// <summary>
        /// 获取状态栏中显示的状态
        /// </summary>
        public virtual ViewModelBase? Status
        {
            get => _Status;
            protected set => this.RaiseAndSetIfChanged(ref _Status, value);
        }

        #endregion

        private IList<MenuItemViewModel>? _MenuItems;
        public virtual IList<MenuItemViewModel>? MenuItems 
        {
            get => _MenuItems;
            protected set => this.RaiseAndSetIfChanged(ref _MenuItems, value);
        }

        protected TabItemViewModel()
        {
            if (IsInDesignMode) return;

            this.CompositeDisposable?.Add(new PropertyChangedEventListener(R.Current)
            {
                (sender, args) => this.RaisePropertyChanged(nameof(this.Name)),
            });
        }

        internal async virtual void Initialize()
        {
            await Task.CompletedTask;
        }
    }
}
