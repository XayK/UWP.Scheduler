using SchedulingApp.Data.Models;
using SchedulingApp.Data.Models.Abstraction;
using SchedulingApp.Data.Models.Elements;
using SchedulingApp.Dialogs;
using SchedulingApp.Presenter.Entities.Elements;
using System;
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
        /// Возвращает <see cref="IMission"/> в случае успешного создания
        /// и возвращает <see langword="null"/>, в случает отмены
        /// </returns>
        public async static Task<IMission> ShowMissionCreation()
        {
            ///TODO: переводы
            MissionDialog dialog = new();
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
        /// Возвращает <see cref="IMission"/>
        /// </returns>
        public async static Task<IMission> EditMission(IMission model)
        {
            ///TODO: переводы
            MissionDialog dialog = new()
            {
                MissionTitle = model.Title,
                StartDate = model.StartDateTime.Date,
                StartTime = model.StartDateTime.TimeOfDay,
                EndDate = model.EndDateTime.Date,
                EndTime = model.EndDateTime.TimeOfDay,
                IsImportant = model.IsImportant
            };

            foreach (var item in model.Descriptions)
            {
                dialog.Descriptions.Add(new RowItemViewModel(item as RowItem));
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
