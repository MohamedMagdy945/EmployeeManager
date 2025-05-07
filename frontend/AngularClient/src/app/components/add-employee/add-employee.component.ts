import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { IEmployee } from '../../Models/Employee';
import { EmployeeService } from '../../services/employee.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-employee',
  imports: [ReactiveFormsModule, RouterModule],
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.css',
})
export class AddEmployeeComponent implements OnInit {
  addEmployeeForm: FormGroup;
  constructor(
    private router: ActivatedRoute,
    private employeeService: EmployeeService,
    private toast: ToastrService,
    private route: Router
  ) {
    this.addEmployeeForm = new FormGroup({
      id: new FormControl(null),
      firstName: new FormControl('', [
        Validators.required,
        Validators.pattern('^[a-zA-Z]{3,10}'),
      ]),
      lastName: new FormControl('', [
        Validators.required,
        Validators.pattern('^[a-zA-Z]{3,10}'),
      ]),
      email: new FormControl('', [Validators.required, Validators.email]),
      position: new FormControl('', [Validators.required]),
      imageUrl: new FormControl(''),
    });
  }
  currentId: number = 0;
  employee: IEmployee | null = null;
  ngOnInit(): void {
    const idParam = this.router.snapshot.paramMap.get('id');
    this.currentId = idParam ? +idParam : 0;
    if (this.currentId != 0) {
      this.employeeService.getEmployeeById(this.currentId).subscribe({
        next: (data) => {
          this.employee = data;
          console.log(this.employee);
          if (this.employee != null) {
            this.addEmployeeForm.patchValue({
              id: this.currentId,
              firstName: this.employee.firstName,
              lastName: this.employee.lastName,
              email: this.employee.email,
              position: this.employee.position,
            });
          }
        },
      });
    }
    error: () => {};
  }

  selectedFile!: File;
  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];
    }
  }

  addOrEditEmployee() {
    if (this.addEmployeeForm.valid) {
      const employee: IEmployee = this.addEmployeeForm.value;
      if (this.currentId == 0) {
        this.employeeService
          .addEmployee(this.addEmployeeForm.value, this.selectedFile)
          .subscribe({
            next: () => {
              this.toast.success('Employee Added successfully');
              this.route.navigate(['employeelist']);
            },
            error: () => {
              this.toast.error('Failed to add Employee');
            },
          });
      } else {
        this.employeeService
          .updateEmployee(this.addEmployeeForm.value, this.selectedFile)
          .subscribe({
            next: () => {
              this.toast.success('Employee Updated successfully');
              this.route.navigate(['employeelist']);
            },
            error: () => {
              this.toast.error('Failed to update Employee');
            },
          });
      }
    }
  }
}
