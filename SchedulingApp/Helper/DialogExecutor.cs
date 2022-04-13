using SchedulingApp.Data.Models;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Data.Models.Elements;
using SchedulingApp.Dialogs;
using SchedulingApp.Presenter.Entities.Abstraction;
using SchedulingApp.Presenter.Entities.Elements;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace SchedulingApp.Helper
{
    /// <summary>
    /// Представляет класс, для запуска и обращения к диалоговым окнам
    /// </summary>
    internal static class DialogExecutor
    {
        /// <summary>
        /// Выполняет действия по запуску диалого окна создания задачи
        /// </summary>
        /// <returns> 
        /// Возвращает <see cref="Mission"/> в случае успешного создания
        /// и возвращает <see langword="null"/>, в случает отмены
        /// </returns>
        public static async Task<Mission> ShowMissionCreation()
        {
            ///TODO: переводы
            MissionDialog dialog = new("Создание");
            var result = await dialog.ShowAsync();

            if (result != ContentDialogResult.Primary)
            {
                return null;
            }

            return dialog.ModelData;
        }

        /// <summary>
        /// Выполняет действия по запуску диалого окна правки задачи
        /// </summary>
        /// <param name="model">Данные модели</param>
        /// <returns> 
        /// Возвращает <see cref="Mission"/> если изменено успешно,
        /// и <see langword="null"/> в случае отмены изменений
        /// </returns>
        public static async Task<Mission> EditMission(Mission model)
        {
            ///TODO: переводы
            MissionDialog dialog = new("Правка")
            {
                MissionTitle = model.Title,
                StartDate = model.StartDateTime.Date,
                StartTime = model.StartDateTime.TimeOfDay,
                EndDate = model.EndDateTime.Date,
                EndTime = model.EndDateTime.TimeOfDay,
                IsImportant = model.IsImportant
            };

            var result = await dialog.ShowAsync();

            if (result != ContentDialogResult.Primary)
            {
                return null;
            }

            return dialog.ModelData;
        }

        /// <summary>
        /// Выполняет действия по запуску диалого окна правки задачи
        /// </summary>
        /// <param name="model">Данные модели</param>
        /// <returns> 
        /// Возвращает <see cref="Mission"/>
        /// </returns>
        public static async Task<ICollection<IRowItem>> EditMissionDescription(Mission model)
        {
            MissionDescriptionDialog dialog = new();

            foreach (var item in model.Descriptions)
            {
                var rowPresenter = new RowItemViewModel(item as RowItem);
                dialog.Descriptions.Add(rowPresenter);
            }

            var result = await dialog.ShowAsync();

            if (result != ContentDialogResult.Primary)
            {
                return null;
            }

            return dialog.ModelData;
        }
    }
}
