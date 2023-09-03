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
        

        // ������������ ���������� � ����� �����
        string fileName = $"{Guid.NewGuid()}.jpg";

        // �������� ������ ���� �� �����
        string filePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

        // �������� ���� ����������
        using (Stream stream = new MemoryStream(_vm.SelectPhoto.photo.Bytes))
        {
            if (stream != null)
            {
                // �������� ���� ���������� � ����
                using (FileStream fileStream = File.Open(filePath, FileMode.Create))
                {
                    await stream.CopyToAsync(fileStream);
                }

                // ������� �����������, �� ���������� ���� ������ ���������
                await App.Current.MainPage.DisplayAlert("����", "���������� ���� ���������" + $"{filePath}", "OK");
            }
            else
            {
                // ������� �����������, �� �� ������� �������� ���� ����������
                await App.Current.MainPage.DisplayAlert("�������", "�� ������� �������� ���� ����������", "OK");
            }
        }
      
    }
}