using BethanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.App.Pages
{
  public partial class EmployeeEdit
  {
    [Inject]
    public IEmployeeDataService EmployeeDataService { get; set; }

    [Inject]
    public ICountryDataService CountryDataService { get; set; }

    [Parameter]
    public string EmployeeId { get; set; }

    public Employee Employee { get; set; } = new Employee();
    public List<Country> Countries { get; set; } = new List<Country>();

    public string CountryId = string.Empty;

    protected async override Task OnInitializedAsync()
    {
      Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
      Countries = (await CountryDataService.GetAllCountries()).ToList();
      CountryId = Employee.CountryId.ToString(); 
    }
  }
}
