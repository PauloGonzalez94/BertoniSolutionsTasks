using BertoniSolutionsTasks.Model;
using BertoniSolutionsTasks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BertoniSolutionsTasks
{
    public partial class MainPage : ContentPage
    {
        private bool CanUpdate;
        public MainPage()
        {
            InitializeComponent();
            Title = "Lista de tareas";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateData();
        }

        public void UpdateData()
        {
            Device.BeginInvokeOnMainThread(async () => {
                CanUpdate = false;
                var data = await TaskRepository.shared.GetWorkToDo();
                this.workList.ItemsSource = data;
                await Task.Delay(1000);
                CanUpdate = true;
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTask());
        }

        private void BtnDelete_Clicked(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () => {
                var obj = (Button)sender;
                var item = (WorkTodo)obj.BindingContext;

                var resp = await DisplayAlert("Eliminar", "Desea eliminar la actividad " + item.Activity, "Aceptar", "Cancelar");
                if (resp)
                {
                    var remove = await TaskRepository.shared.DeleteWordToDo(item);
                    if (remove) this.UpdateData();
                }
            });
        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (!CanUpdate) return;
            var obj = (Switch)sender;
            var item = (WorkTodo)obj.BindingContext;
            //if (item.Done == obj.IsToggled) return;
            //item.Done = obj.IsToggled;
            var updated = await TaskRepository.shared.UpdateWorkToDo(item);
            //if (updated) this.UpdateData();
        }
    }
}
