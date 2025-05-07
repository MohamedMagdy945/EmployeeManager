import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../Models/Pagination';
import { Observable } from 'rxjs';
import { ProductParam } from '../Models/EmployeeParam';
import { IEmployee } from '../Models/Employee';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  baseURL = environment.baseUrl;
  constructor(private http: HttpClient) {}
  getEmployee(productParam: ProductParam): Observable<IPagination> {
    let param = new HttpParams();
    console.log(productParam.Search);
    if (productParam.Search != ' ') {
      param = param.append('Search', productParam.Search);
      console.log(productParam.Search);
    }
    param = param.append('pageNumber', productParam.pageNumber);
    param = param.append('pageSize', productParam.pageSize);
    return this.http.get<IPagination>(this.baseURL + 'Employee/get-all', {
      params: param,
    });
  }
  getEmployeeById(id: number): Observable<IEmployee> {
    return this.http.get<IEmployee>(this.baseURL + 'Employee/get-by-id/' + id);
  }

  addEmployee(employeeData: IEmployee, image: File): Observable<any> {
    const formData = new FormData();
    formData.append('firstName', employeeData.firstName);
    formData.append('lastName', employeeData.lastName);
    formData.append('email', employeeData.email);
    formData.append('position', employeeData.position);
    formData.append('ImageUrlFile', image);
    console.log('gi');
    return this.http.post<any>(
      this.baseURL + 'Employee/add-employee',
      formData
    );
  }
  deleteEmployee(id: number): Observable<void> {
    return this.http.delete<void>(
      this.baseURL + 'Employee/delete-employee/' + id
    );
  }

  updateEmployee(employeeData: IEmployee, image: File): Observable<any> {
    const formData = new FormData();
    formData.append('Id', employeeData.id.toString());
    formData.append('firstName', employeeData.firstName);
    formData.append('lastName', employeeData.lastName);
    formData.append('email', employeeData.email);
    formData.append('position', employeeData.position);
    formData.append('ImageUrlFile', image);

    return this.http.put<any>(
      this.baseURL + 'Employee/update-employee',
      formData
    );
  }
}
