import { Routes } from '@angular/router';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { TestComponent } from './components/test/test.component';

export const routes: Routes = [
  { path: '', component: EmployeeComponent },
  { path: 'employeelist', component: EmployeeComponent },
  { path: 'add-employee', component: AddEmployeeComponent },
  { path: 'add-employee/:id', component: AddEmployeeComponent },
  { path: 'test', component: TestComponent },
];
