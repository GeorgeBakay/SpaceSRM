using SpaceSRM.Date.Interface;
using SpaceSRM.Date.Models;
using SpaceSRM.Date.Repository;
using SpaceSRM.Models;
using SpaceSRM.ViewModels;

namespace SpaceSRM.Views.Forms.DesktopSetting;


public partial class AddRecordForm : ContentPage
{
    RecordsViewModel _vm = new RecordsViewModel();
    private readonly IRecord recordConnection = new RecordRepository();

    private bool IsFirst = true;
    private bool isInitialized = false;
    private bool IsAddClient = true;
    private bool IsEditWork = false; 
    public AddRecordForm()
    {
       
        BindingContext = _vm;

    }
    
    //Loading add record page 
    //Loading visual elements
    //Loading Data of clients
    //Calculation Sum of all works
    protected override async void OnAppearing()
    {
        
        await Task.Delay(500);
        if (IsFirst)
        {
            InitializeComponent();
            await _vm.LoadingDataEmployers();
            await _vm.LoadingDataServices();
        }
        if (IsAddClient)
        {       
            await _vm.LoadingDataClients();
            await _vm.VisualDataClients();
            IsAddClient = false;
        }
        
        if (IsEditWork)
        {

        }
        _vm.VisualDataWorks();
        IsFirst = false;
        List<Work> listWork = _vm.Works.ToList();
        _vm.AddRecord.Sum = 0;
        _vm.Sum = 0;
        int y;
        foreach (Work i in listWork)
        {
            y = i.Price;
            _vm.AddRecord.Sum += y;
            _vm.Sum += y;
        }
        base.OnAppearing();

    }
    protected override async void OnDisappearing()
    {
        
        base.OnDisappearing();
        _vm.ClearVisualWorks();
        
    }
    void OnChangeSeachClient(object sender, EventArgs e)
    {
        SearchBar SB = (SearchBar)sender;
        CheckClient.ItemsSource = _vm.Clients.Where(u => u.Phone.Contains(SB.Text));
        CheckClient.SelectedItem = _vm.SelectClient;
    }
    private async void OnAddClient(object sender, EventArgs e)
    {
        IsAddClient = true;
        _vm.ClearVisualClients();
        Forms.DesktopSetting.AddClientForm page = new Forms.DesktopSetting.AddClientForm();
        await Navigation.PushAsync(page);
    }
    private async void OnBack(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void CheckClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Client current)
        {
            if(current != null && current.Name != "")
            {
                Client thisClient = new Client()
                {
                    Id = current.Id,
                    Name = current.Name,
                    SurName = current.SurName,
                    Phone = current.Phone,
                    Records = current.Records,
                };
                _vm.AddRecord.Client = thisClient;
                _vm.AddRecord.ClientId = thisClient.Id;
            }
            
        }
    }
    private async void OnAddWork(object sender, EventArgs e)
    {
        Views.Forms.Mobile.AddWorkForm page = new Views.Forms.Mobile.AddWorkForm(_vm);
        await Navigation.PushAsync(page);
    }

    public async void PhotoBeforeFromCamera(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.CapturePhotoAsync();
            AddPhotoToBeforePhotos(photo);
        }
    }
    public async void PhotoBeforeFromGallery(object sender, EventArgs e)
    {  
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.PickPhotoAsync();
            AddPhotoToBeforePhotos(photo);
        } 
    }
    public async void PhotoAfterFromCamera(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.CapturePhotoAsync();
            AddPhotoToAfterPhotos(photo);
        }
    }
    public async void PhotoAfterFromGallery(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.PickPhotoAsync();
            AddPhotoToAfterPhotos(photo);
        }
    }

    public async void AddPhotoToBeforePhotos(FileResult photo)
    {
        if (photo != null)
        {
            string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

            using (Stream sourceStream = await photo.OpenReadAsync())
            {
                var memoryStream = new MemoryStream();
                // Copy the contents of the source stream into a new MemoryStream object
                await sourceStream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                CustomPhoto image = new CustomPhoto();

                Photo AddPhoto = new Photo();
                AddPhoto.Bytes = memoryStream.ToArray();
                AddPhoto.FileExtention = photo.ContentType;
                AddPhoto.Size = memoryStream.Length;
                AddPhoto.Type = PhotoType.Before;

                _vm.AddRecord.Photos.Add(AddPhoto);

                var sourceimage = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
                image.ImageC.Source = sourceimage;
                image.photo = AddPhoto;
                _vm.PhotoBefore.Add(image);
            }
        }
    }
    public async void AddPhotoToAfterPhotos(FileResult photo)
    {
        if (photo != null)
        {
            string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

            using (Stream sourceStream = await photo.OpenReadAsync())
            {
                var memoryStream = new MemoryStream();
                // Copy the contents of the source stream into a new MemoryStream object
                await sourceStream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                CustomPhoto image = new CustomPhoto();

                Photo AddPhoto = new Photo();
                AddPhoto.Bytes = memoryStream.ToArray();
                AddPhoto.FileExtention = photo.ContentType;
                AddPhoto.Size = memoryStream.Length;
                AddPhoto.Type = PhotoType.After;
                
                _vm.AddRecord.Photos.Add(AddPhoto);

                var sourceimage = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
                image.ImageC.Source = sourceimage;
                image.photo = AddPhoto;
                
                _vm.PhotoAfter.Add(image);
            }
        }
    }
    public async void BeforePhotoSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
         if (e.CurrentSelection.FirstOrDefault() is CustomPhoto current)
        {
            bool answer = await DisplayAlert("SpaceSRM інформує",
                "Ви точно хочете видалити це зображення",
                "Ні","Так");
            if (!answer)
            {
                
                _vm.AddRecord.Photos.Remove(current.photo);
                _vm.PhotoBefore.Remove(current);
            }
        }
    }
    public async void AfterPhotoSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is CustomPhoto current)
        {
            bool answer = await DisplayAlert("SpaceSRM інформує",
                "Ви точно хочете видалити це зображення",
                "Ні", "Так");
            if (!answer)
            {
                _vm.AddRecord.Photos.Remove(current.photo);
                _vm.PhotoAfter.Remove(current);
            }
        }
    }
    private void DateStartDateSelected(object sender, DateChangedEventArgs e)
    {
        DateTimeStartFill();
    }
    private void TimeStartPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        DateTimeStartFill();
    }
    public void DateTimeStartFill()
    {
        try
        {
            var time = TimeStart.Time;
            var date = DateStart.Date;
            DateTime newDate = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds);
            _vm.AddRecord.DateStart = newDate;
        }
        catch
        {

        }
    }
    public void DateTimeEndFill()
    {
        try
        {
            var time = TimeEnd.Time;
            var date = DateEnd.Date;
            DateTime newDate = new DateTime(date.Year, date.Month, date.Day, time.Hours, time.Minutes, time.Seconds);
            _vm.AddRecord.DateEnd = newDate;
        }
        catch
        {

        }
        
    }

    private void DateEndDateSelected(object sender, DateChangedEventArgs e)
    {
        DateTimeEndFill();
    }
    private void TimeEndPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        DateTimeEndFill();
    }

    private void StatusPickerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        try
        {
            string answer = StatusPicker.SelectedItem.ToString();
            switch (answer)
            {
                case "Запис":
                    _vm.AddRecord.Status = Status.Wait;
                    break;
                case "В роботі":
                    _vm.AddRecord.Status = Status.Work;
                    break;
                case "Виконано":
                    _vm.AddRecord.Status = Status.End;
                    break;
                case "Відміна":
                    _vm.AddRecord.Status = Status.Abolition;
                    break;
            }
        }
        catch
        {

        }


    }

    private void DiscountPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        try
        {
            DiscountError.Text = "";
            string answer = DiscountText.Text;
            int Discount;
            if (!(int.TryParse(answer, out Discount)))
            {
                DiscountError.Text = "ви ввели неправильений формат, потрібно тільки цілі числа";
                return;
            }

            if (Discount >= 0 && Discount <= 100)
            {
                _vm.AddRecord.Discount = Discount;

                foreach (Work work1 in _vm.Works)
                {
                //не можна ділити на 0
                    work1.Price = work1.TruePrice  - (work1.TruePrice / 100) * Discount;
                }
                foreach (Work work1 in _vm.AddRecord.Works)
                {
                    work1.Price = work1.TruePrice  - (work1.TruePrice / 100) * Discount;
                }
               
                List<Work> listWork = _vm.Works.ToList();
                
                _vm.AddRecord.Sum = 0;
                _vm.Sum = 0;
                int y;
                foreach (Work i in listWork)
                {
                    y = i.Price;
                    _vm.AddRecord.Sum += y;
                    _vm.Sum += y;
                }

                

                return;
            }
            else
            {
                DiscountError.Text = "введене число не відовідає процентним значенням , тобто не належить від 0 до 100";
                return;
            }
        }
        catch
        {

        }
    }

    private async void WorksSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Work current)
        {
            Forms.Mobile.EditWorkForm page = new Forms.Mobile.EditWorkForm(_vm,current);
            await Navigation.PushAsync(page);
            CollectionWorks.SelectedItem = null;

        }
    }

    private async void SubmitClicked(object sender, EventArgs e)
    {
        
        Record thisRecord =  _vm.AddRecord;
        List<Work> worksToRecord = _vm.WorksData;
        if (worksToRecord == null || worksToRecord.Count == 0)
        {
            Result.TextColor = Color.FromArgb("#FA6D6D");
            Result.Text = "Ви не вибрали перелік робіт";
            return;
            
        }
        else if(DiscountError.Text != "")
        {
            Result.TextColor = Color.FromArgb("#FA6D6D");
            Result.Text = "Значення знижки введені не вірно";
            return;
        }
        else if(thisRecord.Client == null || thisRecord.Client.Name == "")
        {
            Result.TextColor = Color.FromArgb("#FA6D6D");
            Result.Text = "Виберіть клієнта";
            return;
        }
        else
        {
            LoadingAdd.IsRunning = true;
            Result.TextColor = Color.FromArgb("#4ED16B");
            Result.Text = "Загрузка запису...";

            Record recordOutPhoto = new Record()
            {
                ClientId = thisRecord.ClientId,
                Client = thisRecord.Client,
                Works = worksToRecord,
                BodySize = thisRecord.BodySize,
                BodyType = thisRecord.BodyType,
                Brand = thisRecord.Brand,
                NumberOfCar = thisRecord.NumberOfCar,
                DateStart = thisRecord.DateStart,
                GasCount = thisRecord.GasCount,
                DateEnd = thisRecord.DateEnd,
                Sum = thisRecord.Sum,
                Discount = thisRecord.Discount,
                Status = thisRecord.Status,
                SendMessage = thisRecord.SendMessage,
            };
            
          
            int RecordId;
            List<Photo> photosToSend = thisRecord.Photos.ToList();
            string response = await recordConnection.AddRecord(recordOutPhoto);
            
            if (int.TryParse(response,out RecordId))
            {
                Result.Text = Result.Text + "успішно\n";
                Result.Text = "\nЗагрузка фото\n" + Result.Text;
                int i = 1;
                foreach (Photo photo in photosToSend)
                {
                    Result.Text = $"Загрузка {i}го фото...." + Result.Text;
                    response = await recordConnection.AddPhoto(RecordId, photo);
                    if (response == "ok")
                    {
                        Result.Text = Result.Text + "Успішно додано";
                    }
                    else
                    {
                        Result.TextColor = Color.FromArgb("#FA6D6D");
                        Result.Text = "Помилка\n" + response + Result.Text;
                    }
                    i++;
                }
                Result.Text = "Данні успішно обробленні\n" + Result.Text;
                LoadingAdd.IsRunning = false;
            }
            else
            {
                Result.TextColor = Color.FromArgb("#FA6D6D");
                Result.Text = response;
                LoadingAdd.IsRunning = false;
            }
            

        }

    }
}