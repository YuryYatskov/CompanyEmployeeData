﻿using Refit;
using UserDataAccounting.Web.Models;

namespace UserDataAccounting.Web.Services;

public interface IWageService
{
    const string RouteName = "/api/1.0/wage";

    [Get($"{RouteName}s")]
    Task<GetWagesResponse> GetWages();

    [Get($"{RouteName}s" + "/{filter}")]
    Task<GetWagesResponse> GetWageFilters(string filter);

    [Get($"{RouteName}s/onlyTheLatest")]
    Task<GetWagesResponse> GetWagesOnlyTheLatest();

    [Get($"{RouteName}s/medium")]
    Task<GetMediumWagesResponse> GetWagesMedium();

    [Get($"{RouteName}s/employees")]
    Task<GetWagesResponse> GetEmployeesWages();
    
    [Get($"{RouteName}s/parameters")]
    Task<GetWagesParametersResponse> GetWagesParameters();

    [Get(RouteName + "/{departmentId}/{jobId}/{employeeId}/{dateOfWork}")]
    Task<GetWageByIdResponse> GetWageById(int departmentId, int jobId, int employeeId, string dateOfWork);

    [Post(RouteName)]
    Task<CreateWageResponse> CreateWage(CreateWageRequest request);

    [Put(RouteName)]
    Task<UpdateWageResponse> UpdateWage(UpdateWageRequest request);

    [Delete(RouteName + "/{departmentId}/{jobId}/{employeeId}/{dateOfWork}") ]
    Task<DeleteWageResponse> DeleteWage(int departmentId, int jobId, int employeeId, string dateOfWork);
}
