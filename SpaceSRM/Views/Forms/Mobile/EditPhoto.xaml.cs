using SpaceSRM.Date.Models;
using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.Mobile;

public partial class EditPhoto : ContentPage
{
    public RecordsViewModel _vm = new RecordsViewModel();
    public EditPhoto(RecordsViewModel vm)
    {
        BindingContext = _vm = vm;
        InitializeComponent();
    }
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        CustomPhoto photo = _vm.SelectPhoto;
        await _vm.DeletePhoto(photo);
        if (photo.photo.Type == Models.PhotoType.Before)
        {
            _vm.PhotoBeforePrevious.Remove(photo);
        }
        else
        {
            _vm.PhotoAfterPrevious.Remove(photo);
        }
        _vm.SelectPhoto = new CustomPhoto();
        await Navigation.PopAsync();
    }

    private async void Download_Clicked(object sender, EventArgs e)
    {
        

        // Конвертувати зображення в масив байтів
        string fileName = $"{Guid.NewGuid()}.jpg";

        // Отримати повний шлях до файлу
        string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

        // Отримати потік зображення
        using (Stream stream = new MemoryStream(_vm.SelectPhoto.photo.Bytes))
        {
            if (stream != null)
            {
                // Зберегти потік зображення у файл
                using (FileStream fileStream = File.Open(filePath, FileMode.Create))
                {
                    await stream.CopyToAsync(fileStream);
                }

                // Вивести повідомлення, що зображення було успішно збережено
                await App.Current.MainPage.DisplayAlert("Успіх", "Зображення було збережено" + $"{filePath}", "OK");
            }
            else
            {
                // Вивести повідомлення, що не вдалося отримати потік зображення
                await App.Current.MainPage.DisplayAlert("Помилка", "Не вдалося отримати потік зображення", "OK");
            }
        }
      
    }
}