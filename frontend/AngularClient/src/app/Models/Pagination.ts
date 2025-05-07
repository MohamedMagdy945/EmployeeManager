import { IEmployee } from './Employee';

export interface IPagination {
  pageNumber: number;
  pageSize: number;
  totalCount: number;
  data: IEmployee[];
}
