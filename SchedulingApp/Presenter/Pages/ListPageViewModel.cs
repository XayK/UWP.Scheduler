﻿using Microsoft.Toolkit.Mvvm.Input;
using SchedulingApp.Data.Models;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Helper;
using SchedulingApp.Presenter.Entities;
using SchedulingApp.Presenter.Entities.Abstraction;
using SchedulingApp.Presenter.Pages.Abstraction;
using SchedulingApp.Presenter.Pages.Base;
using System;
using System.Collections.ObjectModel;

namespace SchedulingApp.Presenter.Pages
{
    /// <summary>
    /// Представляет данные для страницы, отображающие элементы списком
    /// </summary>
    public class ListPageViewModel : BaseListPageViewModel, IListPageViewModel
    {
        #region Private Properties

        /// <summary>
        /// Представляет реализацию синглтона для <see cref="ListPageViewModel"/>
        /// </summary>
        private static readonly Lazy<ListPageViewModel> _instance = new Lazy<ListPageViewModel>(() => new ListPageViewModel());

        #endregion Private Properties

        #region Public Properties

        /// <summary>
        /// Предоставляет доступ к экземпляру <see cref="ListPageViewModel"/>
        /// </summary>
        public static ListPageViewModel Instance => _instance.Value;

        #endregion Public Properties

        #region Private Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="ListPageViewModel"/>
        /// </summary>
        private ListPageViewModel() : base(new RelayCommand(CreateMission), new RelayCommand(EditSelectedMission), new RelayCommand(DeleteSelectedMission))
        {
        }

        /// <summary>
        /// Вызод удаления выбранной задачи
        /// </summary>
        private static void DeleteSelectedMission()
        {
            ///TODO: удалить выбранную задачу
        }

        /// <summary>
        /// Вызов правки выбранной задачи
        /// </summary>
        private static void EditSelectedMission()
        {
            ///TODO: вызвать диалог правки выбранной задачу
        }

        /// <summary>
        /// Создание новой задачи
        /// </summary>
        private async static void CreateMission()
        {
            IMission model = await DialogExecutor.ShowMissionCreation();

            if(model == null)
            {
                return;
            }

            IMissionViewModel presenter = new MissionViewModel(model as Mission);
            Instance.Missions.Add(presenter);
        }

        #endregion Private Constructors
    }
}
