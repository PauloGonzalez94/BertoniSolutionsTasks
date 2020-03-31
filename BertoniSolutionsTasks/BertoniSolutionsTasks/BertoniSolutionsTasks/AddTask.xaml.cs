using BertoniSolutionsTasks.Model;
using BertoniSolutionsTasks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BertoniSolutionsTasks
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddTask : ContentPage
	{
		public AddTask ()
		{
			InitializeComponent ();
		}

        private async void SaveTask_Clicked(object sender, EventArgs e)
        {
            var text = this.taskDesc.Text;
            if (string.IsNullOrEmpty(text)) return;
            var task = new WorkTodo() { Activity = text };
            var saved = await TaskRepository.shared.AddWorkToDo(task);
            if (saved) await Navigation.PopAsync();
        }
    }
}