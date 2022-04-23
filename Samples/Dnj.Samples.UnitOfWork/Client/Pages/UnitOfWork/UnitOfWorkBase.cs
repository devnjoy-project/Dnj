using Microsoft.AspNetCore.Components;

namespace Dnj.Samples.UnitOfWork.Client.Pages.UnitOfWork
{
    public class UnitOfWorkBase : ComponentBase
    {
        public IEnumerable<UnitOfWork> UnitOfWorkList { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadEmployees);
        }

        private void LoadEmployees()
        {
            System.Threading.Thread.Sleep(2000);
            // Retrieve data from the server and initialize
            // Employees property which the View will bind
        }
    }
}
