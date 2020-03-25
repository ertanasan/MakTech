export interface SearchService {
    activeList: { data: any[], total: number };
    search(filters: any[], action: string);
}
