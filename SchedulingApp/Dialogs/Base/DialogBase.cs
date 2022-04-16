using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;

namespace SchedulingApp.Dialogs.Base
{
    internal abstract class DialogBase : ContentDialog
    {
        #region Private Fields

        /// <summary>
        /// Представляющий результат работы <see cref="ContentDialog"/>
        /// </summary>
        private TaskCompletionSource<ContentDialogResult> _completionSource;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Инициализирует экземпляр <see cref="DialogBase"/>
        /// </summary>
        public DialogBase()
        {
            _completionSource = new TaskCompletionSource<ContentDialogResult>();
        }

        #endregion Public Constructors

        #region Protected Methods

        /// <summary>
        /// Устанаваливает результат диалога как <see cref="ContentDialogResult.None"/>
        /// </summary>
        protected void SetNoneResult()
        {
            _completionSource.TrySetResult(ContentDialogResult.None);
            Hide();
        }

        /// <summary>
        /// Устанаваливает результат диалога как <see cref="ContentDialogResult.Primary"/>
        /// </summary>
        protected void SetPrimaryResult()
        {
            _completionSource.TrySetResult(ContentDialogResult.Primary);
            Hide();
        }

        /// <summary>
        /// Устанаваливает результат диалога как <see cref="ContentDialogResult.Secondary"/>
        /// </summary>
        protected void SetSecondaryResult()
        {
            _completionSource.TrySetResult(ContentDialogResult.Secondary);
            Hide();
        }

        #endregion Protected Methods

        #region Public Methods

        /// <summary>
        /// Осуществляет показ диалогового окна
        /// </summary>
        /// <returns>Результат работы диалога</returns>
        public new IAsyncOperation<ContentDialogResult> ShowAsync()
        {
            IAsyncOperation<ContentDialogResult> asyncOperation = base.ShowAsync();
            asyncOperation.AsTask().
                ContinueWith(task =>
                _completionSource.TrySetResult(task.Result));

            return _completionSource.Task.AsAsyncOperation();
        }

        #endregion Public Methods
    }
}
