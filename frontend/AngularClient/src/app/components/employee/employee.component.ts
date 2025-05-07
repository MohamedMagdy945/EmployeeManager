import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { ProductParam } from '../../Models/EmployeeParam';
import { PaginationComponent } from '../pagination/pagination/pagination.component';
import { IPagination } from '../../Models/Pagination';
import { IEmployee } from '../../Models/Employee';
import { ToastrService } from 'ngx-toastr';
import { RouterLink, RouterModule } from '@angular/router';
import { SweetAlertService } from '../../services/sweet-alert.service';

@Component({
  selector: 'app-employee',
  imports: [PaginationComponent, RouterModule, RouterLink],
  templateUrl: './employee.component.html',
  styleUrl: './employee.component.css',
})
export class EmployeeComponent implements OnInit {
  constructor(
    private employeeService: EmployeeService,
    private toast: ToastrService,
    private alertService: SweetAlertService
  ) {}
  ngOnInit(): void {
    this.getAllEmployee();
  }
  TotalCount!: number;
  productParam = new ProductParam();
  employees!: IEmployee[];
  getAllEmployee() {
    this.employeeService.getEmployee(this.productParam).subscribe({
      next: (value: IPagination) => {
        this.employees = value.data;
        this.TotalCount = value.totalCount;
        this.productParam.pageNumber = value.pageNumber;
        this.productParam.pageSize = value.pageSize;
        // this.toast.success('Employee loaded successfully');
      },
      error(er) {
        console.log(er);
      },
    });
  }
  search!: string;
  OnSearch(Search: string) {
    this.productParam.Search = Search;
    this.getAllEmployee();
  }

  OnChangePage(event: any) {
    this.productParam.pageNumber = event;
    this.getAllEmployee();
  }

  deletEmployee(id: number) {
    this.alertService.confirmDelete().then((result) => {
      if (result.isConfirmed) {
        this.employeeService.deleteEmployee(id).subscribe({
          next: (data) => {
            this.toast.success('Employee Deleted successfully');
            this.getAllEmployee();
          },
        });
        error: () => {
          this.toast.error('Failed to delete employee');
          console.error('Delete error:');
        };
      }
    });
  }
}
