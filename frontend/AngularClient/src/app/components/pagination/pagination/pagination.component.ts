import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-pagination',
  imports: [PaginationModule],
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.css',
})
export class PaginationComponent {
  @Input() pageSize!: number;
  @Input() totalCount!: number;
  @Output() pageChanged = new EventEmitter();
  OnChangePage(ev: any) {
    this.pageChanged.emit(ev);
  }
}
