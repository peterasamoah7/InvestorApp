type PagedModel<T> = {
    firstPage: string,
    lastPage: string,
    nextPage: string,
    previousPage: string,
    pageNumber: number,
    pageSize: number,
    totalRecords: number,
    totalPages: number,
    items: Array<T>
}

type InvestorModel = {
    id: number,
    name: string,
    type: string,
    dateAdded: string,
    country: string,
    totalCommitment: number
}

type CommitmentSummray = {
    id: number,
    key: string,
    total: number
}

type CommitmentModel = {
    id: number,
    assetClass: string,
    currency: string,
    amount: number
}

